# stereoptic
Stereo Frequency Visualizer

- [ ] Get L and R signals with NAudio[^1][^2] or CSCore
- [ ] Apply FFT or DFT to get frequencies
- [ ] Draw frequencies in a form
- [ ] Make the form transparent
- [ ] Make the form always on top
- [ ] Improve configurability
- [ ] Set up for system tray

[^1]: Ran into latency issues with the NAudio buffer, basically un-usable for games because I need real-time. CSCore claims to be built for real-time processing.
[^2]: Ahh might be cap! I have found other solutions where people have achieved visualization of audio-in with relatively low latency (eyeballing, like 70-100ms).
