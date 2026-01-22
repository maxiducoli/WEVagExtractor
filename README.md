# Extractor de VAGs — by CARP

🔊 *Herramienta para extraer archivos de audio `.VAG` desde contenedores `.RA` de Winning Eleven 2002 y otras versiones.*

En *Winning Eleven 2002* (y títulos relacionados), los comentarios, relatos y efectos de sonido están empaquetados en archivos **`.RA`**, que actúan como contenedores de múltiples clips en formato **`.VAG`** (el estándar de audio comprimido usado originalmente en PlayStation).

Esta utilidad permite **extraer cada clip `.VAG` individual** del archivo `.RA`, facilitando su análisis, conversión a WAV o reemplazo por versiones personalizadas.

---

## 🛠️ Funcionalidades

- Lee archivos `.RA` compatibles con *Winning Eleven 2002* (PC).
- Identifica y extrae todos los clips `.VAG` contenidos.
- Guarda cada clip como archivo independiente (`audio_001.vag`, `audio_002.vag`, etc.).
- Compatible con otras versiones del juego que usen la misma estructura RA/VAG.

> 🔧 Los archivos `.VAG` extraídos pueden convertirse a `.WAV` con herramientas como **VAG2WAV** (incluida en tu suite CARP) para edición de audio.

---

## 💻 Tecnología

- **Lenguaje**: C#  
- **Framework**: .NET  
- **Tipo**: Utilidad de escritorio (Windows)  
- **Uso**: Modding de audio retro / preservación de assets

---

## 🔗 Integración con tu suite

- Los `.VAG` extraídos pueden editarse y reempaquetarse con **RA Maker**.
- Se complementa con **WAV2VAG** para crear nuevos comentarios en castellano u otros idiomas.
- Ideal para usar junto con el **Creador de T_NAME** y otras herramientas visuales para una experiencia 100% personalizada.

---

## 🧠 Inspiración

> *"Si no podés escuchar el audio original, ¿cómo vas a reemplazarlo con tu propia narración?"*

Este extractor es el primer paso en cualquier proyecto serio de localización o mejora de sonido. Porque el modding empieza con entender… y termina con crear.

---

## 📜 Licencia

Uso permitido con fines **no comerciales**. Si reutilizás el código o la idea, citá a **Maximiliano Ducoli (CARP)** como autor original.

---

🎧 ¡Escuchá el juego… y luego dale tu propia voz!
