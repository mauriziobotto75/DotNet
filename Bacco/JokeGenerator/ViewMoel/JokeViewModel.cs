namespace JokeGenerator.ViewModels
{
    public class JokeViewModel : INotifyPropertyChanged
    {
        private readonly JokeService _jokeService;
        private string _currentJoke;
        private string _jokeCategory;
        private string _errorMessage;
        private bool _isLoading;
        private int _jokeCount;

        public string CurrentJoke
        {
            get => _currentJoke;
            set => SetProperty(ref _currentJoke, value);
        }

        public string JokeCategory
        {
            get => _jokeCategory;
            set => SetProperty(ref _jokeCategory, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public int JokeCount
        {
            get => _jokeCount;
            set => SetProperty(ref _jokeCount, value);
        }

        public ICommand GetJokeCommand { get; }
        public ICommand GetJokeByCategoryCommand { get; }
        public ICommand ClearCommand { get; }

        public JokeViewModel()
        {
            _jokeService = new JokeService();
            CurrentJoke = "Click 'Get Joke' to start laughing!";
            JokeCategory = "general";
            JokeCount = 0;

            GetJokeCommand = new RelayCommand(_ => GetRandomJoke());
            GetJokeByCategoryCommand = new RelayCommand(_ => GetJokeByCategory());
            ClearCommand = new RelayCommand(_ => Clear());
        }

        private async void GetRandomJoke()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;
                CurrentJoke = "Loading...";

                var joke = await _jokeService.GetRandomJokeAsync();

                if (joke != null)
                {
                    CurrentJoke = joke.Text;
                    JokeCategory = joke.Category ?? "general";
                    JokeCount++;
                }
                else
                {
                    ErrorMessage = "No joke found. Try again!";
                    CurrentJoke = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
                CurrentJoke = string.Empty;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void GetJokeByCategory()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;
                CurrentJoke = "Loading...";

                var joke = await _jokeService.GetJokeByCategoryAsync(JokeCategory);

                if (joke != null)
                {
                    CurrentJoke = joke.Text;
                    JokeCount++;
                }
                else
                {
                    ErrorMessage = $"No jokes found for category: {JokeCategory}";
                    CurrentJoke = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
                CurrentJoke = string.Empty;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void Clear()
        {
            CurrentJoke = string.Empty;
            ErrorMessage = string.Empty;
            JokeCount = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
