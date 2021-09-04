using UnityEngine;
using UnityEngine.Events;
using System;
using System.Text;

/// <summary>
/// The application log
/// </summary>
public static class Logger
{
    private static StringBuilder log = new StringBuilder();

    /// <summary>
    /// An event that is triggered every time a new message is added to the log
    /// </summary>
    public static UnityEvent onNewMessage = new UnityEvent();

    /// <summary>
    /// Subscribes to the new log message event
    /// </summary>
    /// <param name="callback">The callback method</param>
    public static void Subscribe(UnityAction callback)
    {
        onNewMessage.AddListener(callback);
    }

    /// <summary>
    /// Gets the log contents
    /// </summary>
    /// <returns>The log contents</returns>
    public static string Print()
    {
        return log.ToString();
    }

    /// <summary>
    /// Adds a message to the log
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display</param>
    public static void Log(object message)
    {
        log.Append(DateTime.Now.ToString("[HH:mm:ss] "));
        log.Append("[INFO] ");
        log.AppendLine(message.ToString());
        onNewMessage.Invoke();
    }

    /// <summary>
    /// Adds a warning to the log
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display</param>
    public static void LogWarning(object message)
    {
        log.Append(DateTime.Now.ToString("[HH:mm:ss] "));
        log.Append("[WARNING] ");
        log.AppendLine(message.ToString());
        onNewMessage.Invoke();
    }

    /// <summary>
    /// Adds an error to the log
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display</param>
    public static void LogError(object message)
    {
        log.Append(DateTime.Now.ToString("[HH:mm:ss] "));
        log.Append("[ERROR] ");
        log.AppendLine(message.ToString());
        onNewMessage.Invoke();
    }

    /// <summary>
    /// Adds an exception to the log
    /// </summary>
    /// <param name="exception">Runtime Exception</param>
    public static void LogException(Exception exception)
    {
        log.Append(DateTime.Now.ToString("[HH:mm:ss] "));
        log.Append("[EXCEPTION] ");
        log.AppendLine(exception.ToString());
        onNewMessage.Invoke();
    }
}