using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator
{
    public interface ILogger
    {
        void Info(object message);
        void Warning(object message);
        void Error(object message);
        void Exception(Exception exception);
    }

    public class BlankLogger : ILogger
    {
        public void Error(object message)
        {
        }

        public void Exception(Exception exception)
        {
        }

        public void Info(object message)
        {
        }

        public void Warning(object message)
        {
        }
    }

    public class UnityLogger : ILogger
    {
        public void Error(object message)
        {
            Debug.LogError(message);
        }

        public void Exception(Exception exception)
        {
            Debug.LogException(exception);
        }

        public void Info(object message)
        {
            Debug.Log(message);
        }

        public void Warning(object message)
        {
            Debug.LogWarning(message);
        }
    }
}
#endif
