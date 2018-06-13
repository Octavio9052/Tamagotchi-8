package com.outlook.octavio.armenta.models;

import java.util.List;

public class User {
    public String name;
    public String GUID;
    public String userId;
    public List<Animal> creations;

    @Deprecated
    public String photoUri;
}
