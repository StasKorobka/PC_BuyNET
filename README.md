
This is a simple ASP.NET MVC WEB application 

**Technologies used:**
 - ASP.NET
 - HTML
 - CSS
 - Razor View
 - Bootstrap
 - JS
 - JS Querry

## DB Diagram
![Database diagram](/Assets/DbDiagram.png)
For better view go to this [link](https://dbdesigner.page.link/78cpFF8AXcjtgMNB6)
## Features
### Items
The Items feature allows users to browse a catalog of PC-related products displayed in a  grid, with each item presented in a card showing its name, price, category, average rating, and image. Users can filter items using a sidebar with category selection, a price range slider, and price sorting options (ascending/descending).  AJAX-powered buttons enable adding items to the cart or wishlist without page reloads, and clicking an item navigates to a details page (`Item/ViewItem`) where users can view full descriptions and submit reviews.

### Account

PC-BuyNET uses ASP.NET Core Identity for secure account management, allowing users to register, log in, and manage their profiles. Authenticated users can access personalized features like adding items to their wishlist, submitting reviews, and managing their cart. 
##### Admins
Admins, identified by the “Admin” role, have exclusive access to category management (`Category/Index`), where they can manage categories. Authentication is enforced with `[Authorize]` attributes, ensuring only logged-in users can perform sensitive actions, and anti-forgery tokens secure AJAX requests. The account system integrates seamlessly with the UI, providing a smooth and secure user experience.

### logging

Logging in PC-BuyNET is implemented using ASP.NET Core’s built-in `ILogger<T>` interface, injected into services like `ReviewService`, `CategoryService`, and `WishlistService` for consistent error tracking and debugging. Logs are output to the console and can be extended to other providers (e.g., file, Application Insights) via configuration in `Program.cs`. 

*Example*

When user adds item to the cart, following logging message is displayed in the console :

    info: PC_BuyNET.Data.Services.LoggingService[0]
    Added item 1 to cart for user 6afde60d-7401-4df0-9016-912c1294ce0d.
  
   Or if an error occurs: 
   
    fail: PC_BuyNET.Data.Services.LoggingService[0]
    Item with ID 88 not found.

### Unit testing


