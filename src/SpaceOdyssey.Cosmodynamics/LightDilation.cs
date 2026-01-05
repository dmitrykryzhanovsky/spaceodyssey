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
    }
}