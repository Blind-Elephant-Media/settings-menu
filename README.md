<div align="center">

# `⚙️ bem-settings-menu`

**Easy and quick settings menu to make development easier**

[![Bem Opensource](https://img.shields.io/badge/bem-open%20source-blueviolet.svg)](#)
[![Discord](https://img.shields.io/badge/discord-%237289da.svg?logo=discord)](https://discord.gg/7mqsYMzWdh)
[![Unity Version](https://img.shields.io/badge/Unity-2021%20LTS-black.svg?logo=unity)](https://unity.com/releases/lts)
</div>

## Why not use this?

- The specific folder used might have certain limitations or requirements that could affect its functionality.
- The reliance on text files for data storage might not be suitable for complex or large-scale data due to potential performance issues.
- The method might not be compatible with platforms that do not support text-based data storage.
- Unity PlayerPrefs is more reliable if a text file is not needed.

## Why use this?

- It utilizes a text file within a specific folder in the Unity game engine, allowing developers to access assets via file path, regardless of the build target.
- The choice of a text file for data storage offers several advantages, including easy online storage. Platforms like Steam can readily store and retrieve text-based data.
- This method ensures that all essential data is preserved in a straightforward, accessible format, providing an effective solution for online information storage.
- You want to store more than just strings, ints, and floats
- You like to live on the edge! (It works well now, but future issues may arise. Proceed with caution.)
