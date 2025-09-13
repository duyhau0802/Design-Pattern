using System;
using System.Data.SqlClient;

public class Logger
{
    // B1: Static instance
    private static readonly Logger _instance = new Logger();
    // B2: Private constructor to prevent instantiation from outside
    private Logger() { }
    // B3: Public static method to provide access to the instance
    public static Logger Instance => _instance;

    // #region Locker-based Singleton (Commented Out)
    // Static initialization ở trên mặc định thread-safe trong ngôn ngữ C#
    // Không cần khóa bổ sung
    // private static readonly object _lock = new object();
    // public static Logger Instance
    // {
    //     get
    //     {
    //         if (_instance == null)
    //         {
    //             lock (_lock)
    //             {
    //                 if (_instance == null)
    //                     _instance = new Logger();
    //             }
    //         }
    //         return _instance;
    //     }
    // }
    // #endregion

    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }

    public static void Main(string[] args)
    {
        // In the main method, call public static method to get the instance
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;

        logger1.Log("This is a singleton logger instance.");

        // Check if both instances are the same
        Console.WriteLine($"Are both instances the same? {logger1 == logger2}");
    }
}