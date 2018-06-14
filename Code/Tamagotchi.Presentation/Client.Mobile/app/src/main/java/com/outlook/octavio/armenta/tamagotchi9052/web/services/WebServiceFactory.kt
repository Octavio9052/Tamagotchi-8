package com.outlook.octavio.armenta.tamagotchi9052.web.services

import retrofit2.Retrofit


class WebServiceFactory {

    val retrofit: Retrofit = Retrofit.Builder()
            .baseUrl("http://localhost:39052") // awdwdw https://www.google.com/api/
            .build()

    fun <T> getService(serviceType: Class<T>): T? {
        return retrofit.create(serviceType)
    }

}