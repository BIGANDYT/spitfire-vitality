Spitfire
========

What is the goal of this project?
--------------------------------

-   A demo solution that our sales team can use to demonstrate Sitecore
    features to customers or partners, and adapt to a customers’
    requirements from CMS functions to Experience Marketing. It should
    be slick, agile, and have a wow factor that shows off all of
    Sitecore's key selling points, aligning where possible to the SBOS
    ROI calculator.

-   A demo solution that can be used to show new features to the analyst
    community before general release.

-   A demo solution that can be used to rapidly create tailored
    demonstrations for prospects, there may be certain content or
    Experience Marketing based scenarios that we need to demonstrate.

-   A demo solution that can be provided as a content editor sandbox,
    where content authors follow a pre-defined script to evaluate
    Sitecore.

-   A demo solution that can be provided to prospects on a hosted
    development machine, for prospects who wish to trial development on
    the platform.

-   A demo solution that can be used by the product team to test the
    product before release.

-   A demo solution that can be used for training.

-   A demo solution that can show off our strategic products.

-   A demo solution for SBOS to use to highlight business optimisation
    and the power of the DMS.

Getting started
---------------

-   Clone this repository to your local file system.

-   Open up a command prompt (cmd.exe) **as Administrator** and navigate
    to the build directory.

-   Type `install` and press Enter.

Automated installation
----------------------

-   Pulls down Sitecore and necessary packages from the build server to
    c:\\SpitfireInstaller on your local machine.

-   Installs Sitecore and packages with complex installations using a
    command-line hook into the **Sitecore Instance Manager** (SIM). SIM
    supports manifests for complex post-installation steps such as
    attaching extra databases, running SQL scripts, etc.

-   Adds hostnames for each of the verticals as extra bindings in IIS
    and also into the Windows “hosts” file.

-   Builds and deploys the solution to the newly installed Sitecore
    website.

-   Installs the more simple Sitecore packages using Sitecore Ship.

-   Deploys the source controlled content items onto the Core and Master
    databases using Unicorn.

-   Rebuilds the link databases

-   Deploys marketing assets such as Goals, Campaigns, Path Experience
    Maps and Outcomes.

-   Re-indexes the System (Quick Search), Core and Master search
    indexes.

-   Smart publishes to the Web database.

Build server process
--------------------

-   Run the same install.cmd that is run on developer workstations.

-   Quality control rules run through SonarQube with FxCop, StyleCop and
    Resharper plugins.

-   The command-line hook into the Sitecore Instance Manager (SIM) is
    used to create an export of the instance of Sitecore, including
    files, SQL databases and MongoDB databases.

Resources
---------

-   Bug-tracking: [Bugherd](http://www.bugherd.com/projects/68546/kanban)
-   Build server: [TeamCity](http://sitecoreci.cloudapp.net:8075/)
-   Code quality: [SonarQube](http://sitecoreci.cloudapp.net:9000/dashboard/index/Spitfire)
-   Builds: [SIM Exports](http://spitfire-builds.sitecoresandbox.net/)

How can I contribute?
---------------------

Contact [Andy Thompson](mailto:ant@sitecore.net) or [Steve
McGill](mailto:smg@sitecore.net)