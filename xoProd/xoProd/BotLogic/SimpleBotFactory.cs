namespace xoProd
{
    public class SimpleBotFactory : BotFactory
    {
        public override AbstractBot CreateBot()
        {
            return new SimpleBot();
        }
    }
}