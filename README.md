# Universal Inject Generator - Csharp Edition
Csharp version of https://github.com/d0k3/Universal-Inject-Generator

**Currently a work in progress...**

**Requires .NET framework 4.5 and Visual Studio to compile.**

**This is written and built in Visual Studio 2015 Community Edition.**

Uses standard winforms controls as well as Syncfusion.Shared.Base.dll (included here) from http://syncfusion.com/products/communitylicense (Essential Studio for Windows Forms) - current version i use is v13.4.0.53.

---

This will generate inject-ready apps from homebrew CIAs to inject over the Health & Safety app in the 3DS console. The package includes code by MergeExheader (by @Syphurith), CTRtool (by profi200) and 3DStool (by dnasdw). 

This is used in conjunction with most recent (d0k3's) Decrypt9's "Dump Health&Safety" and "Inject Health&Safety" features. You can only inject .apps smaller or equal in size to the original H&S app. Decrypt9 has a safety check build in and won't proceed with bigger ones. Per CIA, two inject apps will be created - with and without banner - the one with a banner is preferable, but may be to large to inject.

This is how it works:
* Put hs.app (dumped via Decrypt9) plus a homebrew CIA of your choice into the folder next to this exe. (currently only supports single cia files)
* Run Universal Inject Generator.exe, you'll get two inject-ready .app files. One with original banner and one with the inject app banner.
* If the last one for some reason doesn't work, you may try deep-decrypting (via Decrypt9) your CIAs first.
* To inject, rename inject-ready .app to hs.app, put it into the root of your 3DS SD card and inject via Decrypt9.

You should always generate your inject-ready .apps yourself and never take ones from other persons. There might be a version mismatch in the H&S app, leading to it not working otherwise.

Discuss this script here: http://gbatemp.net/threads/project-injecting-any-app-into-health-and-safety.401697/
