db = new Mongo().getDB("admin");

db.createUser(
  {
    user: "regAdmin",
    pwd: "r3g1234R3G",
    roles: [ { role: "userAdminAnyDatabase", db: "admin" }, "readWriteAnyDatabase" ]
  }
);

db.createUser(
    {
      user: "regService",
      pwd: "r3g1S3rvice",
      roles: [ { role: "readWrite", db: "registration" }]
    }
  );