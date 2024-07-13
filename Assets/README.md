## Evaluation of Project
### Advantages
- Reduced Usage of MonoBehaviors by having multiple C# classes 
- Clear Assets folder structure, though would appreciate more division within folders. Ex: Textures folder can be divided into Textures/Skin1, Textures/Skin2, Textures/UI, etc.
- Each script does follow One Class, One Responsibility Principle.
- Resource.Load() usage. 

### Disadvantages
- Scripts lack comments, minimal amount of comments is appreciated for backtracking and finding usage.
- Lack of namespaces to isolate codes, and in the future to create assembly definitions.
- Some part of the Scripts folder doesn't make sense. Ex: 2 Folders with similar name: Utils - Utility, name is similar.
- Naming Convention doesn't follow the official convention from C#. Usually using **PascalCase**, **camelCase** instead of the current **hungarian_notation** convention. Followed by inconsistent naming scheme of scripts. Ex: eSwipeDirection.cs

### Suggestions 
- Follow correct naming conventions of C#: [Naming Conventions](https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md)
- Adding namespaces.
- Write a tool to help with getting path for Resource.Load() to prevent bloating the Constants.cs.