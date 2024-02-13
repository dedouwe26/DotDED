namespace DotDED
{
    public class Window
    {
        public SFML.Graphics.RenderWindow window = new(new(800, 600), "DotDED");
        public void InitWindow() {
            window.SetVerticalSyncEnabled(true);

            window.Closed += (sender, args) => window.Close();

            while (window.IsOpen) {

                HandleEvents();
                Update();
                Draw();

            }
        }
        public void HandleEvents()
        {
            window.DispatchEvents();
        }
        public void Update() {

        }
        public void Draw() {
            window.Clear(SFML.Graphics.Color.Blue);
            window.Display();
        }
    }
}