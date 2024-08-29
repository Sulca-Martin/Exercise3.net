namespace EjercicioObilagotorio3
{
    public abstract class Persona
    {
        //Properties
        private string _name;
        public string Name 
        {
            get { return _name; } 
            set { _name = value; } 
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _rol;
        public string Rol
        {
            get { return _rol; }
            set 
            {
                if (value.ToLower() == "profesor" || value.ToLower() == "pasante")
                    _rol = value;
                else
                    throw new ArgumentException("El rol debe ser profesor o pasante");
            }
        }
    }
}

/*
// Escenario Weather Forecast mejorado

var input = "";                         //Variable que guarda los valores ingresados por teclado
Random random = new Random();           //Variable que genera valores aleatorios

int[,] temperaturas = new int[5, 7];     //Matriz para guardar las temperaturas del mes

double[] temp_prom = new double[5];     //Arreglo utilizado para guardar el promedio de temperatura semanal en la opcion 2

List<(string, string)> umbral = new List<(string, string)>();      //Lista que guarda el dia y temperatura para la opcion 3

double suma_prom;                       //Variable que guarda el promedio de temperatura mensual en la opcion 3

List<string> temperaturas_max_min = new List<string>();          //Lista que guarda el dia de temperatura maxima y minima, se ocupa en la opcion 5 y 6

int min, max;                            //Variable de la temperatura minima y maxima utilizada en la opcion 5, 6 y 7

//Item 1
#region Carga de temperaturas
while (true)
{
    Console.WriteLine("Bienvenido al programa Weather Forecast.\n");
    Console.WriteLine("Ingrese 1 si desea cargar las temperaturas manualmente.\nIngrese 2 si desea cargar las temperaturas automaticamente.\n");
    input = Console.ReadLine();

    if (input == "1" | input == "2")
    {
        Console.Clear();
        if (input == "1")
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 4 && j > 2)        //Restringe que se guarden valores fueras del mes, a pesar de que ya sean valores igual a 0
                    {
                        break;
                    }
                    else
                    {
                        while (true)                //Restringe que solo escriba valores validos, de lo contrario sigue en bucle
                        {
                            Console.WriteLine($"Ingrese el valor de la temperatura de la semana {i + 1} dia {j + 1}.");
                            input = Console.ReadLine();
                            if (input != "" && int.TryParse(input, out int casteo))             //Verificamos que se escribio en la variable algun valor valido
                            {
                                if (casteo > -21 && casteo < 51)                //restringimos que escriba valores reales
                                {
                                    temperaturas[i, j] = casteo;
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese valores de temperatura dentro del rango de la realidad entre -20 grados y 50 grados celcius.");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Debe ingresar un numero.");
                                Console.ReadKey();
                            }
                            Console.Clear();
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Ingrese cualquier tecla para ingresar todas las temperaturas del mes.");
            Console.ReadKey();
            Console.Clear();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 4 && j > 2)        //Restringe que se guarden valores fueras del mes, a pesar de que ya sean valores igual a 0
                    {
                        break;
                    }
                    else
                    {
                        temperaturas[i, j] = random.Next(-20, 50);      //Genera valores aleatorios entre un rango real al arreglo
                    }
                }
            }
        }
        break;
    }
    else
    {
        Console.WriteLine("Debe ingresar un valor valido.");
        Console.ReadKey();
        Console.Clear();
    }
}
#endregion

void opcion1()
{
    while (true)
    {
        Console.WriteLine("Ingrese el numero del dia que desea ver la temperatura.");
        input = Console.ReadLine();
        if (input != "" && int.TryParse(input, out int casteo) && casteo > 0 && casteo < 32)    //Restringimos a que ingrese un dia del mes
        {
            casteo = casteo - 1;            // restamos en 1 para que coincida con los valores de nuestro arreglo, dado que comienza desde el 0
            switch (temperaturas[casteo / 7, casteo % 7])       //divide el valor para calcular la semana, y toma el resto de la division para el dia de la semana
            {
                case < 0:
                    Console.WriteLine("Hizo mucho frio.");
                    break;
                case < 21:
                    Console.WriteLine("El clima estaba fresco.");
                    break;
                default:
                    Console.WriteLine("Hizo calor afuera.");
                    break;
            }
            break;
        }
        else
        {
            Console.WriteLine("Ingrese un valor valido.");
            Console.ReadKey();
        }
        Console.Clear();
    }
}

void opcion2()
{
    Array.Clear(temp_prom, 0, temp_prom.Length);        //Iniciliza nuevamente en 0 los valores, en caso de volver a consultar

    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 7; j++)
        {
            if (i == 4 && j > 2)
            {
                break;
            }
            else
            {
                temp_prom[i] += temperaturas[i, j];
            }
        }
        if (i == 4)             //restringimos que la ultima semana al contar solo con 3 dias el mes el promedio debe dividirse por esos dias.
        {
            temp_prom[i] = temp_prom[i] / 3;
        }
        else
        {
            temp_prom[i] = temp_prom[i] / 7;
        }
        //No hace falta una coleccion, se puede ir guardando en una variable suma, evitando otro bucle for o asi tambien mostrando dentro del mismo bucle
        Console.WriteLine($"La temperatura promedio de la semana {i + 1} es: {temp_prom[i].ToString("N2")} grados Celcius.");
    }
}

void opcion3()
{
    umbral.Clear();         //Borra todos los datos de la lista, en caso de volver a usarlo, restringiendo la duplicidad

    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 7; j++)
        {
            if (temperaturas[i, j] > 20)         //Si la temperatura del dia es mayor a 20 grados celcius, guardamos el dia, semana y temperatura en una lista
            {
                umbral.Add(((i * 7 + j + 1).ToString(), temperaturas[i, j].ToString()));        //Calcula el dia, transforma los valores en string y los guarda    
            }
        }
    }

    if (umbral.Count > 0)               //Verificamos que al menos un dia tiene una temperatura mayor a 20 grados
    {
        Console.WriteLine("Los dias con temperaturas mayores a 20 grados son:");
        foreach (var valor in umbral)
        {
            Console.WriteLine($"Dia: {valor.Item1}, con temperatura de: {valor.Item2} grados Celsius");
        }
    }
    else
    {
        Console.WriteLine("No hay ningun dia del mes que tenga una temperatura superior a 20 grados.");
    }
}

void opcion4()
{
    suma_prom = 0;              //Lo inicializamos nuevamente, en caso de que se vuelva a ocupar, evitando que se sumen a valores previos guardados

    for (int i = 0; i < 5; i++)                         //Iteramos la matriz principal de las temperaturas y guardamos sus valores
    {
        for (int j = 0; j < 7; j++)
        {
            if (i == 4 && j > 2)                //Restringimos que sume los valores excedentes de la matriz
            {
                break;
            }
            else
            {
                suma_prom += temperaturas[i, j];
            }
        }
    }
    Console.WriteLine($"La temperatura promedio del mes es: {(suma_prom / 31).ToString("N2")} grados Celcius.");
}

void opcion5()
{
    max = -21;                       //Asignamos el valor mas bajo a la variable, forzando a que ingrese en el condicional que guarda el valor maximo

    for (int i = 0; i < 5; i++)                         //Iteramos la matriz principal de las temperaturas
    {
        for (int j = 0; j < 7; j++)
        {
            if (i == 4 && j > 2)
            {
                break;
            }
            else
            {
                if (max < temperaturas[i, j])          //Si la temperatura anterior es menor lo reemplazamos y restauramos la lista
                {
                    max = temperaturas[i, j];
                    temperaturas_max_min = new List<string>();              //Se vuelve a instanciar la lista, para que el tamaño de lista sea nuevamente 0

                    temperaturas_max_min.Add((i * 7 + j + 1).ToString());           //Guarda el dia en el tipo de dato string
                }
                else if (max == temperaturas[i, j])                 // Si es igual seguira añadiendo a la lista
                {
                    temperaturas_max_min.Add((i * 7 + j + 1).ToString());
                }
            }
        }
    }
    Console.WriteLine($"La temperatura maxima fue de: {max} grados Celcius.");
    if (temperaturas_max_min.Count < 2)                                               //Verificamos si la temperatura maxima ocurrio en varios dias
    {
        Console.WriteLine($"En el dia: {temperaturas_max_min[0]}");
    }
    else
    {
        foreach (var valor in temperaturas_max_min)                      //Si ocurrio en varios dias, corremos el bucle mostrando todos ellos
        {
            Console.WriteLine($"En el dia: {valor}.");
        }
    }
}

void opcion6()
{
    min = 51;                       //Asignamos el valor mas alto a la variable, forzando a que ingrese en el condicional que guarda el valor minimo

    for (int i = 0; i < 5; i++)                         //Iteramos la matriz principal de las temperaturas
    {
        for (int j = 0; j < 7; j++)
        {
            if (i == 4 && j > 2)
            {
                break;
            }
            else
            {
                if (min > temperaturas[i, j])          //Si la temperatura anterior es menor lo reemplazamos y restauramos la lista
                {
                    min = temperaturas[i, j];
                    temperaturas_max_min = new List<string>();              //Se vuelve a instanciar la lista, para que el tamaño de lista sea nuevamente 0
                    temperaturas_max_min.Add((i * 7 + j + 1).ToString());           //Guarda el dia en el tipo de dato string
                }
                else if (min == temperaturas[i, j])                 // Si es igual seguira añadiendo a la lista
                {
                    temperaturas_max_min.Add((i * 7 + j + 1).ToString());           //Guarda el dia en el tipo de dato string
                }
            }
        }
    }
    Console.WriteLine($"La temperatura minima fue de: {min} grados Celcius.");
    if (temperaturas_max_min.Count < 2)                                               //Verificamos si la temperatura minima ocurrio en varios dias
    {
        Console.WriteLine($"En el dia: {temperaturas_max_min[0]}");
    }
    else
    {
        foreach (var valor in temperaturas_max_min)                      //Si ocurrio en varios dias, corremos el bucle mostrando todos ellos
        {
            Console.WriteLine($"En el dia: {valor}.");
        }
    }
}

void opcion7()
{
    for (int i = 0; i < 5; i++)
    {
        min = random.Next(-20, 50);
        if (min <= 35)                              //Restringimos que no se pase de los 50 grados la temperatura max, con un rango de 15 grados mas que la minima
        {                                           //Para asemejarse a la realidad
            max = random.Next(min, min + 15);
        }
        else
        {
            max = random.Next(min, 50);
        }

        Console.WriteLine("El dia: " + (i + 1) + " tendra una minima de: " + min + " grados y una maxima de: " + max + " grados.\n");
    }
}

//Item 2 (menu)
#region Menu
while (true)
{
    Console.WriteLine("Elija alguna de las siguientes opciones.\n\n1 - Ver temperatura de un dia del mes.\n2 - Ver temperaturas promedios de cada semana.");
    Console.WriteLine("3 - Ver temperaturas del mes mayores a 20 grados.\n4 - Temperatura promedio del mes.\n5 - Temperatura mas alta del mes.");
    Console.WriteLine("6 - Temperatura mas baja del mes.\n7 - Ver pronostico de los proximos 5 dias.\n\n0 - Salir.\n");
    input = Console.ReadLine();
    Console.Clear();

    if (input != "" && int.TryParse(input, out int casteo) && casteo >= 0 && casteo < 8)     //restringe a que ingrese valores especificados
    {
        if (casteo != 0)                 //Restringimos que ingrese al switch si es que quiere salir, evitando utilizar una variable bandera para cerrar el programa
        {
            switch (casteo)
            {
                case 1:
                    opcion1();
                    break;
                case 2:
                    opcion2();
                    break;
                case 3:
                    opcion3();
                    break;
                case 4:
                    opcion4();
                    break;
                case 5:
                    opcion5();
                    break;
                case 6:
                    opcion6();
                    break;
                case 7:
                    opcion7();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Gracias por utilizar Weather Forecast, hasta luego.");
            Console.ReadKey();
            break;
        }
    }
    else
    {
        Console.WriteLine("Ingrese un valor valido.");
    }
    Console.ReadKey();
    Console.Clear();
}
#endregion
*/