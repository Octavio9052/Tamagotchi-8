package com.outlook.octavio.armenta.tamagotchi9052;

class Token {
    private static final Token ourInstance = new Token();

    private String guid;

    private Token() {
    }

    static Token getInstance() {
        return ourInstance;
    }

    public String getGuid(){
        return guid;
    }

    public void setGuid(String guid) {
        this.guid = guid;
    }
}
