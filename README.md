<a href="https://www.doji-tech.com/">
  <img src="https://www.doji-tech.com/assets/favicon.ico" alt="doji logo" title="Doji" align="right" height="70" />
</a>

# pngcs

[OpenUPM]

PNG image encoding in C#.

## About

This is essentially a fork of [pngcs](https://github.com/leonbloy/pngcs).

Changes:
- turned it into a Unity package
- using Unity's [SharpZipLib] package

---

The main use I have for this is to read/write PNG metadata, which Unity's [EncodeToPNG] method doesn't support.

[OpenUPM]: https://openupm.com/packages/com.doji.pngcs
[SharpZipLib]: https://docs.unity3d.com/Packages/com.unity.sharp-zip-lib@latest
[EncodeToPNG]: https://docs.unity3d.com/ScriptReference/ImageConversion.EncodeToPNG.html
