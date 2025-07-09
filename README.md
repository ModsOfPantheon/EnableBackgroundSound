### Enable Background Sound
Adds a toggle to the Audio tab in the settings to enable sound in the background.
![image](https://github.com/user-attachments/assets/c656ad3b-bf17-4ef4-816b-1431f7f163be)

Prevents `AkSoundEngine.Suspend` from firing with [a harmony patch](https://github.com/ModsOfPantheon/EnableBackgroundSound/blob/master/EnableBackgroundSound/Hooks/AkSoundEngineHook.cs#L11) if enable sound in background is checked.
