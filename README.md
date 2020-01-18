# General Use

## What is Animal Crossing Catalog?
Animal Crossing Catalog is a Windows Form application that is designed to help Animal Crossing players keep track of the items they have acquired in various games, achieve perfect town status, and quickly reference which fish/bugs are available in a given month.

## Which Animal Crossing Games are supported?
Currently Animal Crossing for Gamecube and Wii are fully functional. There will probably be support for the other main franchise games in the future.

## How to install
Unzip the 'Animal Crossing Catalog.zip' file and move the Animal Crossing Catalog folder to the 'C:\Program Files (x86)' directory on your Windows pc. The application will run only if the 'catalog.mdf' file and the 'image resources' folder are present in the same directory as the 'Animal Crossing Catalog.exe'. If you wish, create a shortcut to the 'Animal Crossing Catalog.exe' so that it can be located wherever is convenient for you to access it.

# Technical Use

## The database
The core of this application is the database. The application relies on the catalog.mdf database file to load and update data (whether the item is acquired or not) for the user. This database is composed of many tables which are named like '<qualifier>_<item_type>' where qualifier is for which game (acgc or accf for now) and item_type is what kind of item the user wants to query/modify (furniture, clothes, bugs...).
  
## The application
The application is designed to interact with the database and present the user with the results. The DataGridView component is used to display data from the sql queries. The application filters the database based on several filters the user will input (name of item, where it’s from, etc...). The application is designed with the idea that users can use it quickly since it is meant to replace the .txt file approach of keeping track of what the user acquired.

## The image resources
The image resources are used by the application to change the style of the application. I understand that the provided images may not be very appealing, but I would rather not distribute any images that Nintendo may feel the need to sue me over... All that considered, it is pretty easy to change the images with this application. Simply edit the image and the application will load it, as long as you maintain the file name and type (<item_type>\_ic.png).

## Query files
I have saved all of the files I used to construct the databases. There are also some c# programs mixed in there that were used to generate the query files. Those programs aren't that great, but I figured someone may be interested in seeing how I generated my queries. They are designed to work with Liquefy's catalogs that he has posted but you will need to modify them quite a bit if you want to use them. You may notice that there are some ACWW files there too. I pretty much abandoned that part of the database for the time being as I did not like the way I had generated those query files (they were used in my prototype and since then, I have adopted a better database scheme).

# Bugs
report bugs to: abw4v.dev@gmail.com\n
I am not a perfect programmer, so please report bugs to me! I will add a thank you to this file if you lead me to fixing a bug. 

# Acknowledgements
Nintendo for making great games\n
Liquefy for his great guides that I used to make my database queries
