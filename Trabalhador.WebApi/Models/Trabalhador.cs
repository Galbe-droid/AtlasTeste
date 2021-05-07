using System.ComponentModel.DataAnnotations;

namespace Trabalhador.WebApi.Models
{
    public class TrabalhadorClasse
    {
        public TrabalhadorClasse(){}
        public TrabalhadorClasse(string nome, string sobrenome, float valeTransporte, string cargaDeTrabalho, float custoTotal)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.ValeTransporte = valeTransporte;
            this.CargaDeTrabalho = cargaDeTrabalho;
            this.CustoTotal = CalcularGastos(cargaDeTrabalho, valeTransporte);
        }

        [Key]
        [Required]        
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [Required]
        public float ValeTransporte { get; set; }
        [Required]
        public string CargaDeTrabalho { get; set; }
        public float CustoTotal { get; set; }


        public float CalcularGastos(string cargaDeTrabalho, float valeTransporte)
        {            
            switch(cargaDeTrabalho)
            {
                case "5x2":
                    return Calculo(5, 2, valeTransporte);

                case "6x1":
                    return Calculo(6, 1, valeTransporte);

                case "6x2":
                    return Calculo(6, 2, valeTransporte);

                case "12x36":
                    return Calculo(12, 36, valeTransporte);

                default:
                    return 0;
            }
        }

        public float Calculo(int diasAtivos, int diasLivres, float valeTransporte)
        {
            float valorTotal = 0;
            float preco = valeTransporte;

            int diasAtivosNoAno = 359;

            int x = 0;

            int diasAtivosContados = 0;
            int diasLivresContados = 0;

            while(x < diasAtivosNoAno)
            {
                if(diasAtivosContados < diasAtivos)
                {
                    valorTotal += preco;
                    x++;
                    diasAtivosContados++;
                }
                else if(diasAtivosContados == diasAtivos)
                {
                    x++;
                    if(diasLivresContados == diasLivres)
                    {
                        diasAtivosContados = 0;
                    }
                    else
                    {
                        diasLivresContados++;
                        
                    }
                }
            }
            return valorTotal;
        }
    }
}