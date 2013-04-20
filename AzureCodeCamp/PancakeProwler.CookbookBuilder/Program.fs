// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

namespace PancakeProwler.CookbookBuilder

module Program =

    open Topshelf
    open System
    open Topshelf.HostConfigurators
    open Topshelf.Runtime


    let configureTopshelf f = 
        HostFactory.Run(new Action<_>(f))

    let service (conf : HostConfigurator) (fac : (unit -> 'a)) =
        let service' = conf.Service : Func<_> -> HostConfigurator
        service' (new Func<_>(fac)) |> ignore

    let serviceControl (start : HostControl -> bool) (stop : HostControl -> bool) =
        { new ServiceControl with
            member x.Start hc =
              start hc
            member x.Stop hc =
              stop hc }
    
    let cookbook = 
        let b = CookbookBuilder()
        b.Start   
    
    [<EntryPoint>]
    let main argv = 
        configureTopshelf( fun ) |>int