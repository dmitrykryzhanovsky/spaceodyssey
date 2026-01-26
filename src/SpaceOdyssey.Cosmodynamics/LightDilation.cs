using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public static class LightDilation
    {
        /// <summary>
        /// Возвращает световую задержку между двумя векторами (наблюдателем и спутником) с общим началом координат.
        /// </summary>
        /// <param name="observerPosition">Положение наблюдателя.</param>
        /// <param name="sattelitePosition">Положение спутника (наблюдаемого объекта).</param>
        /// <param name="lightSpeed">Скорость света в тех единицах расстояния, в которых выражены вектора observerPosition и 
        /// sattelitePosition, и тех единицах времени, в которых мы хотим получить значение световой задержки.</param>
        public static double ComputeLightDilation (Vector3 observerPosition, Vector3 sattelitePosition, 
            double lightSpeed)
        {
            return Space3.Distance (observerPosition, sattelitePosition) / lightSpeed;
        }

        /// <summary>
        /// Вычисляет положение спутника (наблюдаемого тела) в системе координат, связанной с наблюдателем, с поправкой на 
        /// световую задержку.
        /// </summary>
        /// <param name="observerPosition">Положение наблюдателя в глобальной системе координат.</param>
        /// <param name="sattelitePosition">Положение спутника (наблюдаемого тела) в глобальной системе координат.</param>
        /// <param name="satteliteVelocity">Скорость спутника (наблюдаемого тела) в глобальной системе координат.</param>
        /// <param name="dilation">Световая задержка спутника относительно наблюдателя.</param>
        /// <returns>Вектор от наблюдателя к положению спутника, которое он занимал dilation время назад (то, которое наблюдатель 
        /// видит вследствие световой задержки в заданный момент времени).</returns>
        public static Vector3 ComputeDilatedPosition (Vector3 observerPosition, Vector3 sattelitePosition, 
            Vector3 satteliteVelocity, double dilation)
        {
            return -observerPosition + sattelitePosition - satteliteVelocity * dilation;
        }
    }
}