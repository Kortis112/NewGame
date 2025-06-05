using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance => instance;

   // ← по умолчанию true, но потом можно переопределить
   protected virtual bool PersistBetweenScenes => true;

    protected virtual void Awake()
    {
        if (instance != null && this.gameObject != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = (T)this;

        if (PersistBetweenScenes && !transform.parent)
            DontDestroyOnLoad(gameObject);
    }
    protected virtual void OnDestroy()
    {
        if (instance == this)               // объект, который удаляется, и есть синглтон
            instance = null;                // ← обнуляем приватное поле
    }

}
