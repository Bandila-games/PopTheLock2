using System.Collections.Generic;

public class EventManager
{
    private Dictionary<int, List<IEventObserver>> eventDictionary;

    public EventManager()
    {
        eventDictionary = new Dictionary<int, List<IEventObserver>>();
    }

    public void RemoveAllEventObservers()
    {

    }

    public void Send(int eventId, object payload = null)
    {
        List<IEventObserver> eventObservers;
        if (eventDictionary.TryGetValue(eventId, out eventObservers))
        {
            for (int i = 0; i < eventObservers.Count; i++)
            {
                eventObservers[i].OnEvent(eventId, payload);
            }
        }
    }

    public void AddListener(IEventObserver eventObserver, int eventId)
    {
        List<IEventObserver> eventObservers;
        if (eventDictionary.TryGetValue(eventId, out eventObservers))
        {
            eventObservers.Add(eventObserver);
        }
        else
        {
            eventObservers = new List<IEventObserver>();
            eventObservers.Add(eventObserver);
            eventDictionary.Add(eventId, eventObservers);
        }
    }

    public void RemoveListener(IEventObserver eventObserver, int eventId)
    {
        //TODO
    }
}
