/**
 * AuthComponent
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { DateOnly } from './dateOnly';


export interface WeatherForecast { 
    date?: DateOnly;
    temperatureC?: number;
    readonly temperatureF?: number;
    summary?: string | null;
}

