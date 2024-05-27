Yuzuriha

Command line tool to process (anime) video file into stiches automatically.

Prototype very early into development, don't expect anything for all but simplest stiches. Also it will likely leak lots of memory so better monitor your RAM usage and stop it when it gets too high.

Usage: drag and drop video file on the executable. This will create folder with the same name as video in the same directory (if that directory already exists it will be deleted) which will contain stiches.

Issues to work on:
Don't hardcode 1080p
Rotating frames
Scaling frames
Selecting median pixels
Parallax effect
Possibly feature matching
Possibly scale space usage
Smoother stiching
Determining when to stop stich (small frame area being relevant, frames blinking, etc.)
Linux