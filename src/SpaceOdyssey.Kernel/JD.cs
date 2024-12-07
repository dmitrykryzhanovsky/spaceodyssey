namespace SpaceOdyssey
{
    /// <summary>
    /// Методы для работы с юлианскими датами.
    /// </summary>
    /// <remarks><list type="bullet">
    /// <item>Формулы для перевода между юлианскими и календарными датами взяты из [https://ru.wikipedia.org/wiki/Юлианская_дата].</item>
    /// <item>Годы до нашей эры записываются в астрономическом формате: 1 г. до н. э. = 0, 49 г. до н.э. = -48.</item>
    /// <item>Отсчёт юлианских дат начинается с 1 января 4713 г. до н.э. по юлианскому календарю (старому стилю) = (-4712, 1, 1). 
    /// Полдень этой даты – момент JD = 0.0, а JDN для неё равен 0 (так как прошло 0 суток с момента начала отсчёта юлианских дат).</item>
    /// <item>Значения юлианских дат для тестирования брались из [https://www.onlineconversion.com/julian_date.htm].</item>
    /// </list></remarks>
    public static class JD
    {
        /// <summary>
        /// Возвращает количество юлианских столетий между датой <paramref name="jd"/> и датой <paramref name="referenceEpoch"/>.
        /// </summary>
        /// <remarks>Если дата <paramref name="jd"/> была раньше даты <paramref name="referenceEpoch"/>, будет возвращено отрицательное 
        /// значение.</remarks>
        public static double GetJulianCenturies (double jd, double referenceEpoch = AstroConst.Epoch.J2000)
        {
            return (jd - referenceEpoch) / AstroConst.Time.JulianCentury;
        }
    }
}