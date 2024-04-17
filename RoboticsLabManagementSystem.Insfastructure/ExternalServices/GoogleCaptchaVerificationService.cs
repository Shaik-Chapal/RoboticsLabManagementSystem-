using RoboticsLabManagementSystem.Application.ExternalServices;
using Newtonsoft.Json;

namespace RoboticsLabManagementSystem.Infrastructure.ExternalServices
{
    public class GoogleCaptchaVerificationService : ICaptchaVerificationService
    {
        private readonly string _secretKey;

        public GoogleCaptchaVerificationService(string secretKey)
        {
            _secretKey = secretKey;
        }

        public async Task<bool> VerifyCaptchaToken(string token)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={_secretKey}&response={token}");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    dynamic captchaResult = JsonConvert.DeserializeObject(responseBody);
                    return captchaResult.success;
                }
            }

            return false;
        }
    }
}