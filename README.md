#DeDuper Application

Overview
DeDuper is a Windows Forms application designed to identify duplicate images within a specified directory. It uses perceptual hashing to determine similarity between images, providing an efficient and effective means of decluttering your image collection.

Features
Directory Scanning: Users can select a directory for scanning through an easy-to-use graphical interface.
Duplicate Detection: Employs perceptual hashing (pHash) to find and group similar images based on a user-defined similarity threshold.
Progress Tracking: Provides real-time feedback on the scanning progress with a progress bar.

How It Works
The application uses a combination of image processing techniques to compare images:

Image Resizing: Images are resized to a uniform smaller size to standardize the comparison process.
Grayscale Conversion: Images are converted to grayscale to focus on structural similarities rather than color differences.
Hash Generation: A binary hash is generated for each image based on whether pixels are darker or lighter than the average color.
Similarity Scoring: Computes Hamming distances between image hashes to determine similarity, grouping images that fall within the specified threshold.

Usage
Start the Application: Run DeDuper.exe.
Choose Directory: Use the 'Choose Directory' button to select the folder you want to scan.
Set Threshold: Adjust the similarity threshold using the slider.
Scan for Duplicates: Click the 'Scan' button to begin scanning. Results will be displayed in a grid view.

Building the Application
To build the application from source:

Open DeDuper.sln in Visual Studio.
Build the solution to produce the executable.
Contributing
Contributions to DeDuper are welcome. Please feel free to fork the repository, make improvements, and submit pull requests.
