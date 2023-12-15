using UnityEngine;

namespace TDLN.CameraControllers
{
    public class RotacionA : MonoBehaviour
    {
        public GameObject target;
        public float distance = 10.0f;

        public float xSpeed = 250.0f;
        public float ySpeed = 120.0f;

        public float yMinLimit = -20;
        public float yMaxLimit = 80;

        float x = 0.0f;
        float y = 0.0f;

        public float rotationSpeed = 10.0f; // Nueva variable para la velocidad de rotaci�n autom�tica

        void Start()
        {
            var angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
        }

        void LateUpdate()
        {
            if (distance < 2) distance = 2;

            // Rotaci�n autom�tica
            x += rotationSpeed * Time.deltaTime;

            // Aseg�rate de que el �ngulo y est� dentro de los l�mites
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            // Calcular la rotaci�n y posici�n
            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.transform.position;

            // Aplicar la rotaci�n y posici�n a la c�mara
            transform.rotation = rotation;
            transform.position = position;
        }

        static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }
    }
}