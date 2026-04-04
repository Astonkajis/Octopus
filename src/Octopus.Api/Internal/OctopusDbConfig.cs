namespace Octopus.Api.Internal
{
    /// <summary>
    /// Represents configuration settings for the Octopus database connection.
    /// </summary>
    public class OctopusDbConfig
    {
        private const string SectionName = "ConnectionStrings";

        /// <summary>
        /// Octopus Core database connection string.
        /// </summary>
        public string OctopusCore { get; set; } = default!;

        /// <summary>
        /// Creates a new instance of the OctopusDbConfig class by binding configuration values from the specified
        /// appsettings.json.
        /// </summary>
        /// <param name="configuration">The appsettings containing the values to bind to the OctopusDbConfig instance. Must not be null.</param>
        /// <returns>A new OctopusDbConfig instance populated with values from the appsettings.json.</returns>
        public static OctopusDbConfig Get(IConfiguration configuration)
        {
            var config = new OctopusDbConfig();
            configuration.GetSection(SectionName).Bind(config);

            return config;
        }
    }
}
