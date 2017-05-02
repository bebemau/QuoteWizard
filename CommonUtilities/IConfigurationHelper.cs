namespace CommonUtilities
{
    public interface IConfigurationHelper
    {
        T Get<T>(string key);
    }
}