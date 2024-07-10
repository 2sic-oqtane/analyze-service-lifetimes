# Analyze Service Lifetimes in Oqtane

This is a project to analyze the service lifetimes in Oqtane.

This is important, because Oqtane has various rendering modes, and each results in different service lifetimes.

## Oqtane Rendering Modes

1. Server-Side Blazor (Static, SSR)
1. Interactive, where the client is in a separate / shared process on the server
1. Client-Side Blazor (WebAssembly, WASM)

Each of these scenarios results in services being shared / reused in different ways.