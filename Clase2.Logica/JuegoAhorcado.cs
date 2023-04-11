using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Logica;

public class JuegoAhorcado
{

    public void ahorcado()
    {

        string[] palabrasFaciles = { "gato", "perro", "casa", "mesa", "juego" };
        string[] palabrasMedias = { "televisor", "computadora", "automovil", "reloj", "bicicleta" };
        string[] palabrasDificiles = { "electroencefalografista", "inconstitucionalidad", "parangaricutirimicuaro", "hipopotomonstrosesquipedaliofobia", "desoxirribonucleico" };
        string[] palabras;
        int vidas = 8;
        string palabraElegida = "";
        char[] letrasUsadas = new char[26];
        int numLetrasUsadas = 0;

        Console.WriteLine("¡Bienvenido al juego del ahorcado!");

        Console.WriteLine("Seleccione la dificultad del juego: ");
        Console.WriteLine("1 - Fácil");
        Console.WriteLine("2 - Media");
        Console.WriteLine("3 - Difícil");

        int dificultad = int.Parse(Console.ReadLine());

        switch (dificultad)
        {
            case 1:
                palabras = palabrasFaciles;
                break;
            case 2:
                palabras = palabrasMedias;
                break;
            case 3:
                palabras = palabrasDificiles;
                break;
            default:
                palabras = palabrasFaciles;
                break;
        }

        Random rand = new Random();
        palabraElegida = palabras[rand.Next(palabras.Length)];

        char[] letrasPalabraElegida = palabraElegida.ToCharArray();
        char[] letrasAdivinadas = new char[palabraElegida.Length];

        for (int i = 0; i < letrasAdivinadas.Length; i++)
        {
            letrasAdivinadas[i] = '_';
        }

        while (vidas > 0 && new string(letrasAdivinadas) != palabraElegida)
        {
            Console.WriteLine("Vidas restantes: " + vidas);
            Console.WriteLine("Letras usadas: " + new string(letrasUsadas));
            Console.WriteLine("Palabra: " + new string(letrasAdivinadas));

            Console.WriteLine("Ingrese una letra: ");
            char letra = Console.ReadLine().ToLower()[0];

            if (letrasUsadas.Contains(letra))
            {
                Console.WriteLine("Ya has usado esa letra. Intenta con otra.");
                continue;
            }

            letrasUsadas[numLetrasUsadas++] = letra;

            if (letrasPalabraElegida.Contains(letra))
            {
                for (int i = 0; i < letrasPalabraElegida.Length; i++)
                {
                    if (letrasPalabraElegida[i] == letra)
                    {
                        letrasAdivinadas[i] = letra;
                    }
                }
            }
            else
            {
                Console.WriteLine("La letra " + letra + " no se encuentra en la palabra.");
                vidas--;

                switch (vidas)
                {
                   case 7:
                            Console.WriteLine(@"
  _________
 |/        |
 |         
 |         
 |          
 |          
_|___      
");
                break;
                        case 6:
                            Console.WriteLine(@"
  _________
 |/        |
 |         O
 |         
 |          
 |          
_|___      
");
                break;
                        case 5:
                            Console.WriteLine(@"
  _________
 |/        |
 |         O
 |         |
 |          
 |          
_|___      
");
                break;
                        case 4:
                            Console.WriteLine(@"
  _________
 |/        |
 |         O
 |        /|
 |          
 |          
_|___
");
                break;
                            case 3:
                            Console.WriteLine(@"
 _________
 |/        |
 |         O
 |        /|\
 |          
 |          
_|___
");
                break;
                            case 2:
                            Console.WriteLine(@"
_________
 |/        |
 |         O
 |        /|\
 |        /  
 |          
_|___");
                break;
                            case 1:
                            Console.WriteLine(@"
_________
 |/        |
 |         O
 |        /|\
 |        / \ 
 |          
_|___");
                break;



            }
            }
        }

        if (vidas == 0)
        {
            Console.WriteLine("Perdiste. La palabra era: " + palabraElegida);
        }
        else
        {
            Console.WriteLine("¡Ganaste! La palabra era: " + palabraElegida);
        }

        Console.WriteLine("Presione cualquier tecla para salir.");
        Console.ReadKey();

    }
}
