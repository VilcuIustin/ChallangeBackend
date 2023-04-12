namespace ChallangeBackend.MethodExtensions
{
    public static class ConfigureSwagger
    {

        public static void AddSwaggerConfiguration(this ServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}
