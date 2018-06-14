package com.outlook.octavio.armenta.tamagotchi9052.web.services

import com.google.gson.Gson
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory


class WebServiceFactory {

    val retrofit: Retrofit = Retrofit.Builder()
            .baseUrl("http://localhost:39052/api/") // awdwdw https://www.google.com/api/
            .addConverterFactory(GsonConverterFactory.create())
            .build()

    fun <T> getService(serviceType: Class<T>): T? {
        return retrofit.create(serviceType)
    }

}