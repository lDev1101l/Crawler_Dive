Welome traveller!
This is my Project that just for now involves only the Web crawler itself. 
In the future I may add a Scraper or any other features, so stay tuned if you`re interested ;) 

And some explanation aswell:

The project theme was chosen for several reasons:

`Learning the Basics of Web Scraping`: The project provides an opportunity to gain a deeper understanding of how web scraping and web crawling work, how to extract data from web pages, work with HTML, and manage HTTP requests.

`Practice working with libraries`: HtmlAgilityPack is a powerful library for working with HTML documents in C#.

`Managing Recursion and Data Structures`: The web crawler uses recursion and collections to track visited URLs. This will help improve your understanding of these topics.

`Error and Exception Handling`: The code provides basic exception handling. You can improve it by adding logging and more accurate handling of various errors.

`Extensibility`: The code is easily extended and modified. 
You can add features such as:
-Time limit for crawling.
-Additional criteria for selecting links.
-Saving data to a database or files.
-Processing and analysis of collected data.

`Improving Programming Skills`: Working with a real project helps improve programming skills, code debugging and testing.

The execution time of a given program can be estimated using complexity analysis in "O" (big O) notation. The main factors that affect execution time include the depth of recursion, the number of links on each page, and the uniqueness of the URL.

`Complexity Analysis`

Recursion depth (D):

The program recursively traverses links up to depth level 5.
This is a fixed depth level that does not depend on the input data, so you can think of it as a constant D=5.
Number of links on each page (`L`):

For each page, the program retrieves all links. Let the average number of links on a page be L.
Unique URLs (`U`):

The program maintains a list of visited URLs. In the worst case, it can visit all unique URLs at each level of recursion.
Difficulty rating
Each recursion level visits up to L new links. In the worst case, the number of pages visited at each level doubles, resulting in an exponential increase in the number of pages visited.

However, given a fixed recursion depth, the total number of pages visited in the worst case can be estimated as:

`T(n)=O(L↑D)`

Where:

L - average number of links on the page,
D is the maximum recursion depth (in this case 5).

`Final grade.`
Time complexity: `O(L↑5)`

Time complexity is exponential in the number of links on the page and the fixed recursion depth. This means that as the number of links on each page increases, the execution time increases exponentially.

Space complexity: `O(U)`

Spatial complexity is determined by the number of unique URLs that must be stored in memory to prevent repeat visits. In the worst case, the program stores all unique URLs, resulting in O(U) spatial complexity.

Conclusion
Although the time complexity of this program is exponential due to the depth of recursion and the number of links in the pages, the fixed depth of 5 levels makes it more manageable for small projects or tests. For larger projects or to improve performance, you may need optimizations such as asynchronous execution, limiting the number of requests, and more complex link handling.

