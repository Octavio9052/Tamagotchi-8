package com.outlook.octavio.armenta.tamagotchi9052;

class Token {
    private static final Token ourInstance = new Token();

    static Token getInstance() {
        return ourInstance;
    }

    private Token() {
    }
}
