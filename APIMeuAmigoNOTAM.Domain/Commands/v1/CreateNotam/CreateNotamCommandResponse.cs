namespace APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam
{
    public class CreateNotamCommandResponse
    {
        public string Id { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}