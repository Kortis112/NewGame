using UnityEngine;

namespace Game.Systems
{
    /// <summary>Данные одного забега – живут пока открыт Play-сценарий.</summary>
    public static class RunData
    {
        public static int goldRun;          // золото, набраное за текущий забег
        public static int currentNode;      // индекс активной ноды графа
        public static NodeGraph graph;      // сгенерированный маршрут комнат
        public static int hpCur;
        public static int hpMax;
        public static int staminaCur;
        public static int activeSlot;    // 0-based
        public static bool runFinished;
    }
}
