public interface IEventObserver
{
    void OnEvent(int eventId, object payload);
}
