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

        public float rotationSpeed = 10.0f; // Nueva variable para la velocidad de rotación automática

        void Start()
        {
            var angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
        }

        void LateUpdate()
        {
            if (distance < 2) distance = 2;

            // Rotación automática
            x += rotationSpeed * Time.deltaTime;

            // Asegúrate de que el ángulo y esté dentro de los límites
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            // Calcular la rotación y posición
            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.transform.position;

            // Aplicar la rotación y posición a la cámara
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