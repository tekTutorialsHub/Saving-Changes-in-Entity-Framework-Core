# Saving-Changes-in-Entity-Framework-Core
Saving Changes in Entity Framework Core

Entity Framework Core Save Changes to the database using the SaveChanges method of DbContext. When we use the SaveChanges it prepares the corresponding insert, update, delete queries. It then wraps them in a Transaction and sends it to the database. If any of the queries fails all the statements are rolled back. The Context also manages the entity objects during run time, which includes populating objects with data from a database, change tracking, etc.


[Save Changes in Entity Framework Core](https://www.tektutorialshub.com/entity-framework-core/save-changes-in-entity-framework-core/)

[ChangeTracker, EntityEntry & Entity States](https://www.tektutorialshub.com/entity-framework-core/change-tracker-entity-states-in-entity-framework-core/)

[Add Records/Add Multiple Records](https://www.tektutorialshub.com/entity-framework-core/add-record-add-multiple-records-in-entity-framework/)

[Update Record](https://www.tektutorialshub.com/entity-framework-core/update-record-in-entity-framework-core/)

[Delete Record](https://www.tektutorialshub.com/entity-framework-core/deleting-records-in-entity-framework-core/)

