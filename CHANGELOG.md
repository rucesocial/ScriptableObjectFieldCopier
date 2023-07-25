# Changelog for ScriptableObject Field Copier

All notable changes to this project will be documented in this file.

## [1.1.2] - 2023-07-25

### Added

- Implemented copy and paste operations into the context menu. Now you can perform copy-paste operations on a scriptable object directly from the context menu in the Unity Editor.
- Code has been reorganized into regions for better readability and maintenance.

## [1.1.1] - 2023-07-23

### Fixed

- This commit addresses the issue where some objects were being copied by reference in our ScriptableObject copying process. This was causing undesired behavior where a change in one instance would affect all copied instances. 

- We've now implemented a deep copy mechanism to ensure that each copied ScriptableObject is a completely separate instance, preventing changes in one from affecting the others. This fix enhances the reliability and expected behavior of our ScriptableObject copying process.


## [1.1.0] - 2023-07-23

### Added

- Added listing of SerializeField fields.

## [1.0.0] - 2023-07-23

### Added

- Initial release of the package.