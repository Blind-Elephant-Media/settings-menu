<div align="center">

# `⚙️ bem-settings-menu`

**Easy and quick settings menu to make development easier**

[![Bem Opensource](https://img.shields.io/badge/bem-open%20source-blueviolet.svg)](#)
[![Discord](https://img.shields.io/badge/discord-%237289da.svg?logo=discord)](https://discord.gg/7mqsYMzWdh)
[![Unity Version](https://img.shields.io/badge/Unity-2021%20LTS-black.svg?logo=unity)](https://unity.com/releases/lts)
</div>
The Blind Elephant Media Settings Menu operates through a mechanism that involves the storage of data on a text file. This text file is located within the StreamingAssets folder, a special directory in the Unity game engine.

The StreamingAssets folder is a read-only location in Unity, which allows developers to access assets by file path, irrespective of the build target. In this case, the Blind Elephant Media Settings Menu utilizes this feature to store its data.

The choice of using a text file for data storage offers several advantages. One of the primary benefits is that it allows for easy online storage. For instance, platforms like Steam can readily store and retrieve text-based data. This method ensures that all the necessary data is preserved in a simple, accessible format, making it an efficient solution for storing information online.

In essence, the Blind Elephant Media Settings Menu’s functionality hinges on its ability to store and retrieve data from a text file within Unity’s StreamingAssets folder. This approach not only simplifies online storage but also enhances the overall user experience by ensuring seamless data management.
