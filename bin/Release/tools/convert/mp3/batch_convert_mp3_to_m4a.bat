@echo off
for %%G in (*.mp3) do ffmpeg -loop 1 -i cover.jpg -i %%~nxG -c:a aac -ar 48000 -c:v h264 -pix_fmt yuv420p -vf "fps=24/1.001" -shortest -strict -2 %%~nxG.mp4