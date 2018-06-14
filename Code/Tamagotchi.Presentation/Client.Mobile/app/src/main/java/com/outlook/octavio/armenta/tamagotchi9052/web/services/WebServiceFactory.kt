package com.outlook.octavio.armenta.tamagotchi9052.web.services

import retrofit2.Retrofit

/**
 * @author J. Pichardo
 */
class WebServiceFactory {

    val retrofit: Retrofit = Retrofit.Builder()
            .baseUrl("http://localhost:3000")
            .build()

    fun <T> getService(serviceType: Class<T>): T? {
        return retrofit.create(serviceType)
    }

}