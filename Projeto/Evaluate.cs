using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto
{
    public class Evaluate
    {
        public string Comandos { get; set; }

        public Evaluate(string comando)
        {
            Comandos = comando;
        }

        public static string PosicaoCartesiana(string stringDeCoordenadas) //Metodo que recebe o comando em forma de string e retorna as coordenadas
        {
            if (stringDeCoordenadas == null)
            {
                return ("(999, 999)");
            }

            char[] vetorDeChar = stringDeCoordenadas.ToCharArray();

            if (stringDeCoordenadas == "") {
                return ("(999, 999)");
            }
            if (Int32.TryParse(vetorDeChar[0].ToString(), out int number)){
                return ("(999, 999)");
            };

            return TratamentoDeArray(vetorDeChar);
        }

        private static string TratamentoDeArray(char[] vetor) //Realiza a separação das coordenadas com passo das sem passo
        {
            string[] vetordeString = new string[vetor.Length];

            int contador = 0;
            int contadorString = 0;

            while (contador < vetor.Length)
            {
                bool success = Int32.TryParse(vetor[contador].ToString(), out int number);

                
                if (!success)
                {
                    vetordeString[contadorString] = vetor[contador].ToString();
                    contador++;
                }else
                {
                    while (success)
                    {
                        vetordeString[contadorString - 1] += vetor[contador].ToString();
                        contador++;
                        if (contador >= vetor.Length)
                        {
                            break;
                        }
                        success = Int32.TryParse(vetor[contador].ToString(), out number);
                    }
                    continue;
                }

                contadorString++;
            }//laço que realiza a separação de cada comando(N,S,O,L)


            if (!VerificaErros(vetordeString)) {  //condição que verifica se a string é valida
                return SomaCoordenadas(VerificaX(vetordeString));
            }
            else {
                return "(999, 999)";
            }
        }

        private static string SomaCoordenadas(string[] array) //Metodo que faz trata os comandos e retorna as coordenadas X e Y
        {
            double posicaoX = 0;
            double posicaoY = 0;
            int contador = 0;

            while (contador < array.Length)
            {
                if (array[contador] == null || array[0] == "X") {
                    contador++;
                    continue;

                }
                if (array[contador].Length == 1)
                {
                    if (array[contador] == "N")
                    {
                        posicaoY += 1;
                    }
                    else if (array[contador] == "S")
                    {
                        posicaoY += -1;
                    }
                    else if (array[contador] == "L")
                    {
                        posicaoX += 1;
                    }
                    else if (array[contador] == "O")
                    {
                        posicaoX += -1;
                    }
                    else if (array[contador] == "X")
                    {
                        
                    }
                    else {
                        return ("(" + 999 + ", " + 999 + ")");
                    }
                    
                }
                else{
                    var arrayChar = array[contador].ToCharArray();

                    if (arrayChar[0] == 'N')
                    {
                        int contadordoif = 1;
                        string valor = "";
                        while (contadordoif < arrayChar.Length)
                        {
                            valor += arrayChar[contadordoif].ToString();
                            contadordoif++;
                        }
                        if (Convert.ToDouble(valor) < 1 || Convert.ToDouble(valor) > 2147483647) {
                            return ("(999 ,999)");
                        }
                        posicaoY += Convert.ToInt32(valor);

                    }
                    else if (arrayChar[0] == 'S')
                    {

                        int contadordoif = 1;
                        string valor = "";
                        while (contadordoif < arrayChar.Length)
                        {
                            valor += arrayChar[contadordoif].ToString();
                            contadordoif++;
                        }
                        if (Convert.ToInt32(valor) < 1 || Convert.ToInt32(valor) > 2147483647) {
                            return ("(999, 999)");
                        }
                        posicaoY -= Convert.ToInt32(valor);
                    }
                    else if (arrayChar[0] == 'L')
                    {

                        int contadordoif = 1;
                        string valor = "";
                        while (contadordoif < arrayChar.Length)
                        {
                            valor += arrayChar[contadordoif].ToString();
                            contadordoif++;
                        }
                        if (Convert.ToInt32(valor) < 1 || Convert.ToInt32(valor) > 2147483647)
                        {
                            return ("(999, 999)");
                        }
                        posicaoX += Convert.ToInt32(valor);
                    }
                    else if (arrayChar[0] == 'O')
                    {

                        int contadordoif = 1;
                        string valor = "";
                        while (contadordoif < arrayChar.Length)
                        {
                            valor += arrayChar[contadordoif].ToString();
                            contadordoif++;
                        }
                        if (Convert.ToInt32(valor) < 1 || Convert.ToInt32(valor) > 2147483647)
                        {
                            return ("(999, 999)");
                        }
                        posicaoX -= Convert.ToInt32(valor);
                    }
                    else if (array[contador] == "X")
                    {
                       
                    }
                    else
                    {
                        return ("(999, 999)");
                    }
                }

                contador++;
            } //laço que realiza as somas das devidas coordenadas com e sem passo

            if (posicaoX > 2147483647 || posicaoY > 2147483647) {
                return ("(999, 999)");
            }
            return ("("+posicaoX+", "+posicaoY+")");
        }

        private static string[] VerificaX(string[] array) // Verifica e remove as coordenadas quando X aparece
        {
            int cont = 0;
            while(cont < array.Length){
                if (array[cont] == "X") {
                    int contX = 0;
                    while (array[cont + contX] == "X") {  //laço que verifica intervalos de posições em que o X aparece
                        contX++;
                        if (cont + contX >= array.Length) {
                            break;
                        }
                    }
                    while (contX > 0) { //laço que realiza a anulação dos comandos de acordo com as posições de X
                        array[cont - contX] = null;
                        contX--;
                    }
                }
                cont++;
            }
            return array;
        }

        private static bool VerificaErros(string[] array) //Metodo que realiza a verificação de posições de numeros ou X invalidos
        { 
            if (Int32.TryParse(array[0], out int number) || array[0] == "X")// verifica se a primeira posição do array é numero ou X
            {
                return true;
            }
            else{
                return false;
            }
        }

    }
}
