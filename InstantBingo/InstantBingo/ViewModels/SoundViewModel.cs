using System;
using System.Collections.Generic;
using Caliburn.Micro;
using InstantBingo.Messages;

namespace InstantBingo.ViewModels
{
    public class SoundViewModel : PropertyChangedBase, IHandle<PlaySound>, IHandle<SoundSetting>
    {                
        private readonly Uri WINNING_SOUND_URI = new Uri("ms-appx:///Assets/WinningSound.wma");
        private readonly Uri BUTTON_SOUND_URI = new Uri("ms-appx:///Assets/ButtonSound.wav");        
        private bool _soundEnabled = true;
        private readonly IDictionary<SoundType, Uri> _soundsDictionary;

        public Uri WinningSoundUri
        {
            get
            {
                return _soundsDictionary.ContainsKey(SoundType.WinningSound)
                    ? _soundsDictionary[SoundType.WinningSound]
                    : null;
            }
        }

        public Uri ButtonSoundUri
        {
            get
            {
                return _soundsDictionary.ContainsKey(SoundType.ButtonSound)
                    ? _soundsDictionary[SoundType.ButtonSound]
                    : null;
            }
        }

        public SoundViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);

            _soundsDictionary = new Dictionary<SoundType, Uri>
            {
                {SoundType.WinningSound, null},
                {SoundType.ButtonSound, null},
            };
        }        

        public void Handle(SoundSetting soundSetting)
        {
            _soundEnabled = soundSetting.IsEnabled;
        }

        public void Handle(PlaySound playSound)
        {
            if (playSound.IsPlay)
            {
                PlaySound(playSound.Type);
            }
            else
            {
                StopSound(playSound.Type);
            }
        }

        public void PlaySound(SoundType sound)
        {
            switch (sound)
            {
                case SoundType.WinningSound:
                    _soundsDictionary[SoundType.WinningSound] = _soundEnabled ? WINNING_SOUND_URI : null;
                    NotifyOfPropertyChange(() => WinningSoundUri);
                    break;
                case SoundType.ButtonSound:
                    _soundsDictionary[SoundType.ButtonSound] = _soundEnabled ? BUTTON_SOUND_URI : null;
                    NotifyOfPropertyChange(() => ButtonSoundUri);
                    break;    
            }
        }

        public void StopSound(SoundType sound)
        {
            switch (sound)
            {
                case SoundType.WinningSound:
                    _soundsDictionary[SoundType.WinningSound] = null;
                    NotifyOfPropertyChange(() => WinningSoundUri);
                    break;
                case SoundType.ButtonSound:
                    _soundsDictionary[SoundType.ButtonSound] = null;
                    NotifyOfPropertyChange(() => ButtonSoundUri);
                    break;
            }
        }        
    }
}
