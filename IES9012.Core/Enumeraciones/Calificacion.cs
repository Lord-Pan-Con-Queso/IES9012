namespace IES9012.Core.Enumeraciones
{
    public enum Calificacion
    {
        //Un enum asocia un texto a un valor numérico. 
        //De forma predeterminada,los valores de constante asociados a miembros de enumeracion
        //son del tipo entero(int). Comienzan con cero y aumentan en uno despues del orden del texto de la definicion
        //Se puede especificar explícitamente cualquier otro tipo de numero entero como un tipo subyacente de un tipo de numeracion
        //Tambien se puede especificar explicitamente los valores de constante asociados.
        Mal = 0,
        Deficiente = 20,
        Regular = 40,
        Bien = 60,
        MuyBien = 80,
        Sobresaliente = 100,
    }
}