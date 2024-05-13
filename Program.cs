using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(String[] args)
    {
      
        universidad Universidad = new universidad();

        Console.WriteLine("**************************************************************************");
        Alumno alumno1 = new Alumno("Anuar", 18, Alumno.Carreras.Ingenieria_de_Sistemas, "2023-0935U");
        Alumno alumno2 = new Alumno("Alberto", 19, Alumno.Carreras.Ingenieria_Electronica, "2021-1071I");
        Universidad.AgregarAlumnos(alumno1);
        Universidad.AgregarAlumnos(alumno2);
        alumno1.AgregarCalificacion(70);
        alumno2.AgregarCalificacion(59);

        List<Alumno> listaAlumnos = Universidad.obtenerlistaAlum();
        foreach (var alumno in listaAlumnos)
        {
            Console.WriteLine(alumno.DatosdelAlumno());
        }
    }
}

public partial class universidad
{
    private List<Alumno> listaAlumnos;

    public universidad()
    {
        listaAlumnos = new List<Alumno>();
    }
    public void AgregarAlumnos(Alumno alumnos)
    {
        listaAlumnos.Add(alumnos);
    }
    public List<Alumno> obtenerlistaAlum()
    {
        return listaAlumnos;
    }
}


public partial class Alumno
{
    public string nombre { get; set; }
    public int edad { get; set; }
    public string carnet { get; set; }
    public Carreras carrera { get; set; }

    public List<double> calificaciones { get; set; }

    public Alumno(string nombre, int edad, Carreras carrera, String carnet)
    {
        this.nombre = nombre;
        this.edad = edad;
        this.carnet = carnet;
        this.carrera = carrera;
        calificaciones = new List<double>();
    }
    public enum Carreras
    {
        Ingenieria_de_Sistemas,
        Ingenieria_en_Computacion,
        Telecomunicaciones,
        Ingenieria_Electronica
    }

    public string DatosdelAlumno()
    {
        return $"Nombre: {nombre}, Edad: {edad}, Carrera: {carrera}, Carnet: {carnet}, Nota: {EstadoApro()}";
    }
    public void AgregarCalificacion(double calificacion)
    {
        calificaciones.Add(calificacion);
    }
}

public partial class Alumno
{
    public double CalcularPromeCalificaciones()
    {
        if (calificaciones.Count == 0)
        {
            return 0;
        }
        double SumaCalificaciones = 0;
        foreach (var calificacion in calificaciones)
        {
            SumaCalificaciones += calificacion;
        }
        return SumaCalificaciones / calificaciones.Count;
    }
    public String EstadoApro()
    {
        double promedio = CalcularPromeCalificaciones();
        if (promedio >= 60)
        {
            return "aprobado";
        }
        else
        {
            return "reprobado";
        }
    }
}
