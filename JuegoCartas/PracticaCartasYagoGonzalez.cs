using System;
using System.IO;
using System.Threading;
using Barajero;

namespace practica1
{

    class Ejercicios
    {
        public static void Main(string[] args)
        {
            //Inicio del programa con menú de presentación
            String opcion;

            Console.WriteLine("Bienvenido al ejericico de prácticas de Yago");
            Console.WriteLine("Que opcion te gustaría probar?(Elige un numero)");
            Console.WriteLine("1 - Ejercicio 1");
            Console.WriteLine("2 - Ejercicio 2");
            Console.WriteLine("3 - Ejercicio 3");
            Console.WriteLine("4 - Siete y Medio");
            Console.WriteLine("0 - Salir");

            opcion = Console.ReadLine();
            while (opcion != "0" && opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4") 
            {
                Console.WriteLine("Por favor, elige una opcion correcta");
                opcion = Console.ReadLine();
            }

            switch (opcion)
            {
                case "1": ejercicio1(); break;
                case "2": ejercicio2(); break;
                case "3": ejercicio3(); break;
                case "4": sieteYMedio(); break;
                case "0": Environment.Exit(0); break;
            }
        }

        public static void ejercicio1()
        {
            Deck baraja = new Deck();
            baraja.mezclarBaraja();
            Card carta = baraja.SiguienteCarta();
            //Bucle while que continuará escribiendo cartas mientras no haya ninguna null, por lo que mostrará toda la baraja.
            while (carta != null)
            {
                Console.WriteLine("Pulsa intro para sacar la siguiente carta");
                carta.mostrarCarta();
                Console.ReadLine();
                carta = baraja.SiguienteCarta();
                if (carta == null) Console.WriteLine("Ya no hay mas cartas");

            }

        }
        public static void ejercicio2()
        {
            int sacarCartas = 0, numeroPremio = 3, espadas = 0, corazones = 0, bastos = 0, diamantes = 0;
            bool perdido = true;
            bool cartasCorrectas = false;
            bool esEnteroCarta, esEnteroRep;
            bool cartasAcabadas = false;
            bool ganado = false;
            bool juegoAcabado = false;
            Deck baraja = new Deck();
            baraja.mezclarBaraja();

            Console.WriteLine("Bienvenido al juego de adivinar los palos!!");
            Console.WriteLine("En este juego primero indicas cuantas cartas quieres sacar");
            Console.WriteLine("El objetivo es proponer el numero de veces que se va a repetir cualquier palo.");
            Console.WriteLine("Indicas las veces que quieres que se repita y prueba suerte!!");
            Console.WriteLine("Juegue con moderación. Sea responsable");


            while (!cartasCorrectas)
            {

                Console.WriteLine("Cuantas Cartas quieres sacar??");
                esEnteroCarta = Int32.TryParse(Console.ReadLine(), out sacarCartas);
                if (sacarCartas > 52 || sacarCartas <= 0)
                {
                    esEnteroCarta = false;
                    Console.WriteLine("Introduce un numero positivo menor de 52");
                }
                while (esEnteroCarta != true)
                {
                    Console.WriteLine("Por favor introduce un dato valido!");
                    Console.WriteLine("Cuantas Cartas quieres sacar??");
                    esEnteroCarta = Int32.TryParse(Console.ReadLine(), out sacarCartas);
                    if (sacarCartas > 52 || sacarCartas <= 0)
                    {
                        esEnteroCarta = false;
                        Console.WriteLine("Introduce un numero menor de 52");
                        Console.WriteLine("Introduce un numero positivo menor de 52");

                    }

                }


                Console.WriteLine("Numero de veces repetidas??");
                esEnteroRep = Int32.TryParse(Console.ReadLine(), out numeroPremio);
                if (numeroPremio > 13 || numeroPremio < 0)
                {
                    esEnteroRep = false;
                    Console.WriteLine("Solo pueden haber como maximo 13 cartas repetidas, y ya tendrías que tener suerte! Si te salen 13 cartas del mismo palo,ves y compra loteria ahora mismo");
                }
                while (esEnteroRep != true)
                {
                    Console.WriteLine("Por favor introduce un valor numérico!");
                    Console.WriteLine("Numero de veces repetidas??");
                    esEnteroRep = Int32.TryParse(Console.ReadLine(), out numeroPremio);
                    if (numeroPremio > 13 || numeroPremio < 0)
                    {
                        esEnteroRep = false;
                        Console.WriteLine("Solo pueden haber como maximo 13 cartas repetidas, y ya tendrías que tener suerte! Si te salen 13 cartas del mismo palo,\nves y compra loteria ahora mismo");
                    }
                }

                cartasCorrectas = true;

            }

            while (!cartasAcabadas)
            {
                while (!juegoAcabado)
                {
                    while (perdido && !ganado && !juegoAcabado)
                    {
                        espadas = 0; corazones = 0;bastos = 0;diamantes = 0;

                        Console.WriteLine("Cartas disponibles: " + baraja.remainingCards + " - Cartas Sacadas: " + sacarCartas);
                        if (baraja.remainingCards >= sacarCartas)
                        {
                            for (int i = 0; i < sacarCartas; i++)
                            {
                                Card c = baraja.SiguienteCarta();
                                c.mostrarCarta();
                                Thread.Sleep(1000);
                                switch (c.palo)
                                {
                                    case ESuit.Spades: espadas++; break;
                                    case ESuit.Hearts: corazones++; break;
                                    case ESuit.Clubs: bastos++; break;
                                    case ESuit.Diamonds: diamantes++; break;

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Se han acabado las cartas!");
                            //perdido = true;
                            cartasAcabadas = true;
                            juegoAcabado = true;

                        }

                        if (espadas == numeroPremio)
                        {
                            Console.WriteLine("Ole! Tienes " + numeroPremio + " cartas de Espadas, estas hecho un espadachin!!");
                            Console.WriteLine("Has ganado");
                            // perdido = true;
                            ganado = true;

                        }
                        if (corazones == numeroPremio)
                        {
                            Console.WriteLine("Madre! Tienes " + numeroPremio + " cartas de Coraoznes, estas hecho un Don Juan!!!");
                            Console.WriteLine("Has ganado");
                            //perdido = true;
                            ganado = true;

                        }
                        if (bastos == numeroPremio)
                        {
                            Console.WriteLine("DIOS! Tienes " + numeroPremio + " cartas de Bastos, vaya bestia, estas hecho un tigre de bengala, un ballenato de beluga que guapo tio!!!!");
                            Console.WriteLine("Has ganado");
                            // perdido = true;
                            ganado = true;

                        }
                        if (diamantes == numeroPremio)
                        {
                            Console.WriteLine("Vaya tela! Tienes " + numeroPremio + " cartas de Diamantes, shine bright like a diamond!!!");
                            Console.WriteLine("Has ganado");
                            //perdido = true;
                            ganado = true;
                        }
                        if (perdido && !ganado && !cartasAcabadas)
                        {
                            Console.WriteLine("NO HAS DAO NI UNA!!");
                            Console.WriteLine("Oh no! Has perdido, intentalo de nuevo");
                            perdido = true;
                            Thread.Sleep(3000);

                        }
                    }
                    Console.WriteLine("Quieres jugar de nuevo? S/N");
                    if(Console.ReadLine() == "s")
                    {
                        ganado = false;
                    }

                }

            }
        }

        public static void ejercicio3()
        {
            // Declaración de variables
            int TAM;
            int p1Puntuacion = 0, p2Puntuacion = 0, noMano = 1, contador = 0;
            Deck baraja = new Deck();
            bool turno = true;
            baraja.mezclarBaraja();

            // Mensajes de bienvenida y reglas del juego
            Console.WriteLine("Bienvenido al juego de carta más alta!");
            Console.WriteLine("En este juego, juegas contra el ordenador!");
            Console.WriteLine("Primero decides cuántas cartas quieres sacar, después se irán comparando en turno rotatorio");
            Console.WriteLine("Si son del mismo palo se comparan las cartas y se lleva un punto el que tenga la carta más alta. Si son de distinto palo gana el punto quien sacó la primera carta.\nEl turno se pasa siempre al jugador que pierde. El turno inicial se sortea.");

            // Obtener el número de cartas a sacar
            do
            {
                Console.WriteLine("Cuantas Cartas quieres sacar??");
            } while (!Int32.TryParse(Console.ReadLine(), out TAM) || TAM > 52 || TAM <= 0);

            // Crear arreglos para las cartas de cada jugador
            Card[] p1 = new Card[TAM];
            Card[] p2 = new Card[TAM];

            // Juego principal
            while (baraja.remainingCards > TAM)
            {
                Console.WriteLine("Mano numero: " + noMano++);

                // Repartir cartas a ambos jugadores
                for (int i = 0; i < TAM && baraja.remainingCards > TAM; i++)
                {
                    p1[i] = baraja.SiguienteCarta();
                    p2[i] = baraja.SiguienteCarta();
                }

                contador = 0;

                // Comparación de cartas en cada turno
                while (contador < TAM)
                {
                    // Mostrar información de las cartas
                    Console.WriteLine(turno ? "Turno del jugador" : "Turno del Ordenador");
                    Console.WriteLine("Carta numero: " + (contador + 1));
                    Console.WriteLine("===========");
                    Console.WriteLine("Jugador");
                    p1[contador].mostrarCarta();
                    Console.WriteLine("   ---   ");
                    Console.WriteLine("Ordenador");
                    p2[contador].mostrarCarta();
                    Console.WriteLine("===========");
                    Console.WriteLine("Pulsa intro para continuar");
                    Console.ReadLine();

                    // Determinar quién gana el punto
                    if (p1[contador].palo == p2[contador].palo)
                    {
                        if ((turno && p1[contador].valor > p2[contador].valor) || (!turno && p1[contador].valor < p2[contador].valor))
                        {
                            p1Puntuacion++;
                            Console.WriteLine("PUNTO PARA EL JUGADOR!!!!!");
                        }
                        else
                        {
                            p2Puntuacion++;
                            Console.WriteLine("PUNTO PARA EL ORDENADOR!!!!!");
                        }
                    }
                    else
                    {
                        if (turno)
                        {
                            p1Puntuacion++;
                            Console.WriteLine("PUNTO PARA EL JUGADOR!!!!!");
                        }
                        else
                        {
                            p2Puntuacion++;
                            Console.WriteLine("PUNTO PARA EL ORDENADOR!!!!!");
                        }
                    }

                    // Mostrar puntuaciones
                    Console.WriteLine("-----------PUNTUACIONES---------------");
                    Console.WriteLine("Jugador: " + p1Puntuacion + " -- Ordenador: " + p2Puntuacion);

                    // Cambiar el turno
                    turno = !turno;
                    contador++;
                }

                // Mensaje entre manos
                Console.WriteLine("REPARTIENDO OTRA MANO...");
                Thread.Sleep(3000);
            }

            // Mensaje final si no hay suficientes cartas
            Console.WriteLine("No hay cartas suficientes!!");
        }

        public static void sieteYMedio()
        {
            Console.WriteLine("Bienvenido al juego del 7 y medio!!!");

            double p1puntuacion = 0, bancaPuntuacion = 0;
            Card carta, cartaJugador = null;
            String respuesta;

            Deck baraja = new Deck();

            baraja.mezclarBaraja();


            /*FINALMENTE DECIDÍ NO CAMBAIR LA LIBRERIA AUNQUE ESTE SERÍA LA LÓGICA NECESARIA PARA CONSTRUIR UNA BARAJA SIN 8 9 0 10
             EN LUGAR DE CAMBAIR LA LIBRERIA HE INCLUIDO EN LA LÓGICA DEL JUEGO QUE SE IGNOREN ESTAS CARTAS*/

            /*Eliminar 8 9 y 10*/
            
            /*
            Card[] barajaArreglada = new Card[40];

            for (int i = 0; i < barajaArreglada.Length; i++)
            {
                carta = baraja.SiguienteCarta();

                if (carta.valor == ERank.Eight ||
                   carta.valor == ERank.Nine ||
                   carta.valor == ERank.Ten)
                {
                    i = i - 1;
                }
                else
                {
                    barajaArreglada[i] = carta;
                }
                barajaArreglada[i].mostrarCarta();
            }
            //
            */
            
            

            //Logica del juego

            Console.WriteLine(baraja.remainingCards);
            while (baraja.remainingCards > 0)
            {
                p1puntuacion = 0;
                bancaPuntuacion = 0;
                Console.WriteLine("Carta del jugador");
                //Sacar carta del jugador descartando 8 9 y 10
                //Lógica del jugador
                if (p1puntuacion < 7.5)
                {
                    do
                    {
                        carta = baraja.SiguienteCarta();
                        if (carta.valor == ERank.Eight || carta.valor == ERank.Nine || carta.valor == ERank.Ten)
                        {
                            carta = null;
                        }
                        else
                        {
                            cartaJugador = carta;
                        }
                    } while (carta == null);
                    carta.mostrarCarta();

                    if (carta.valor == ERank.Queen || carta.valor == ERank.King || carta.valor == ERank.Jack)
                    {
                        p1puntuacion += 0.5;

                    }
                    else
                    {
                        p1puntuacion += (double)cartaJugador.valor;

                    }
                    Console.WriteLine("Puntuacion actual: " + p1puntuacion);
                    if (p1puntuacion > 7.5)
                    {
                        Console.WriteLine("Puntuacion: " + p1puntuacion + "\nALAA TE HAS PASADO!");
                        break;
                    }
                    Console.WriteLine("Quieres otra carta? s/n");
                    respuesta = Console.ReadLine();
                    while (respuesta == "s")
                    {
                        if (respuesta == "s")
                        {
                            do
                            {
                                carta = baraja.SiguienteCarta();
                                if (carta.valor == ERank.Eight || carta.valor == ERank.Nine || carta.valor == ERank.Ten)
                                {
                                    carta = null;

                                }
                                else
                                {
                                    cartaJugador = carta;
                                }
                            } while (carta == null);
                            carta.mostrarCarta();

                            if (carta.valor == ERank.Queen || carta.valor == ERank.King || carta.valor == ERank.Jack)
                            {
                                p1puntuacion += 0.5;

                            }
                            else
                            {
                                p1puntuacion += (double)cartaJugador.valor;

                            }
                            Console.WriteLine("Puntuacion actual: " + p1puntuacion);
                            if (p1puntuacion > 7.5)
                            {
                                Console.WriteLine("Puntuacion: " + p1puntuacion + "\nALAA TE HAS PASADO!\nSe te han quitado todos los puntos!!");
                                p1puntuacion = 0;
                                break;
                            }
                            Console.WriteLine("Quieres otra carta? s/n");
                            respuesta = Console.ReadLine();


                        }
                        else
                        {
                            Console.WriteLine("Te Plantaste");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Puntuacion: " + p1puntuacion + "\nALAA TE HAS PASADO!");
                    p1puntuacion = 0;
                }

                //Logica de la banca
                Console.WriteLine("Carta de la banca");
                Thread.Sleep(1000);
                Console.Write(". "); Thread.Sleep(1000); Console.Write(". "); Thread.Sleep(1000); Console.Write(". "); Thread.Sleep(1000);
                Console.WriteLine();
                if (bancaPuntuacion < 7.5)
                {
                    do
                    {
                        carta = baraja.SiguienteCarta();
                        if (carta.valor == ERank.Eight || carta.valor == ERank.Nine || carta.valor == ERank.Ten)
                        {
                            carta = null;

                        }
                        else
                        {
                            cartaJugador = carta;
                        }
                    } while (carta == null);
                    carta.mostrarCarta();
                    Thread.Sleep(1000);


                    if (cartaJugador.valor == ERank.Queen || cartaJugador.valor == ERank.King || cartaJugador.valor == ERank.Jack)
                    {
                        bancaPuntuacion += 0.5;

                    }
                    else
                    {
                        bancaPuntuacion += (double)cartaJugador.valor;

                    }

                    while (bancaPuntuacion < 5)
                    {
                        if (bancaPuntuacion < 5)
                        {
                            Console.WriteLine("La banca esta pidiendo otra carta");
                            Thread.Sleep(1000); Console.Write(". "); Thread.Sleep(1000); Console.Write(". "); Thread.Sleep(1000); Console.Write(". "); Thread.Sleep(1000);
                            Console.WriteLine();
                            do
                            {
                                carta = baraja.SiguienteCarta();

                                if (carta.valor == ERank.Eight || carta.valor == ERank.Nine || carta.valor == ERank.Ten)
                                {
                                    carta = null;
                                }
                                else
                                {
                                    cartaJugador = carta;
                                }
                            } while (carta == null);
                            carta.mostrarCarta();
                            Thread.Sleep(1000);




                            if (carta.valor == ERank.Queen || carta.valor == ERank.King || carta.valor == ERank.Jack)
                            {
                                bancaPuntuacion += 0.5;

                            }
                            else
                            {
                                bancaPuntuacion += (double)cartaJugador.valor;

                            }
                            if (bancaPuntuacion > 7.5)
                            {
                                Console.WriteLine("Puntuacion: " + bancaPuntuacion + "\nLA BANCA SE HA PASADO!\nLa banca ha perdido todos sus puntos!!");
                                bancaPuntuacion = 0;
                                break;
                            }


                        }
                        else
                        {
                            Console.WriteLine("La Banca se planta");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Puntuacion de la banca: " + bancaPuntuacion + "\nLA BANCA SE HA PASADO!");
                    bancaPuntuacion = 0;
                }
                Console.WriteLine("Puntuaciones!: \n" + "Jugador: " + p1puntuacion + "\nBanca: " + bancaPuntuacion);

                if (p1puntuacion > bancaPuntuacion && p1puntuacion < 7.5)
                {
                    Console.WriteLine("ENHORABUENA HAS GANADO A LA BANCA!!!!\n\n\n\n\n\n");
                }
                else { Console.WriteLine("HAS PERDIDO..\n\n\n\n\n"); }
                if (p1puntuacion == bancaPuntuacion) { Console.WriteLine("OH WOW HABEIS EMPATADO!!\n\n\n\n\n"); }





            }

        }
    }
}