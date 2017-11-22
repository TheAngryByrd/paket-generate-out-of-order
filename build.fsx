#r @"packages/build/FAKE/tools/FakeLib.dll"
#load @"./.paket/load/net462/build/build.group.fsx"
open Hopac
open HttpFs.Client
open Fake
open Fake.Git
open Fake.ReleaseNotesHelper
open System


let checkGithub () =
    let response =
        Request.createUrl HttpMethod.Get "https://github.com"
        |> HttpFs.Client.getResponse
        |> Hopac.Hopac.run
    if response.statusCode >= 400 then
        failwith "Github down"



Target "CheckGithub" (checkGithub)


RunTargetOrDefault "CheckGithub"
