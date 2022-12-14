# Results

## Sequential

```console
[13:37:38 INF] Using Sequential
[13:37:38 INF] Generating A-0
[13:37:39 INF] WorkItem { Name = A-0 }
[13:37:39 INF] Generating A-1
[13:37:40 INF] WorkItem { Name = A-1 }
[13:37:40 INF] Generating A-2
[13:37:41 INF] WorkItem { Name = A-2 }
[13:37:41 INF] Generating B-0
[13:37:42 INF] WorkItem { Name = B-0 }
[13:37:42 INF] Generating B-1
[13:37:43 INF] WorkItem { Name = B-1 }
[13:37:43 INF] Generating B-2
[13:37:44 INF] WorkItem { Name = B-2 }
```

## Zip

```console
[13:38:13 INF] Using Zip
[13:38:13 INF] Generating A-0
[13:38:14 INF] Generating B-0
[13:38:15 INF] ["WorkItem { Name = A-0 }", "WorkItem { Name = B-0 }"]
[13:38:15 INF] Generating A-1
[13:38:16 INF] Generating B-1
[13:38:17 INF] ["WorkItem { Name = A-1 }", "WorkItem { Name = B-1 }"]
[13:38:17 INF] Generating A-2
[13:38:18 INF] Generating B-2
[13:38:19 INF] ["WorkItem { Name = A-2 }", "WorkItem { Name = B-2 }"]
```

## ZipAwait

```console
[13:31:25 INF] Using ZipAwait
[13:31:25 INF] Generating A-0
[13:31:26 INF] Generating B-0
[13:31:27 INF] ["WorkItem { Name = A-0 }", "WorkItem { Name = B-0 }"]
[13:31:27 INF] Generating A-1
[13:31:28 INF] Generating B-1
[13:31:29 INF] ["WorkItem { Name = A-1 }", "WorkItem { Name = B-1 }"]
[13:31:29 INF] Generating A-2
[13:31:30 INF] Generating B-2
[13:31:31 INF] ["WorkItem { Name = A-2 }", "WorkItem { Name = B-2 }"]
```

## Concat

```console
[13:41:39 INF] Using Concat
[13:41:39 INF] Generating A-0
[13:41:40 INF] WorkItem { Name = A-0 }
[13:41:40 INF] Generating A-1
[13:41:41 INF] WorkItem { Name = A-1 }
[13:41:41 INF] Generating A-2
[13:41:42 INF] WorkItem { Name = A-2 }
[13:41:42 INF] Generating B-0
[13:41:43 INF] WorkItem { Name = B-0 }
[13:41:43 INF] Generating B-1
[13:41:44 INF] WorkItem { Name = B-1 }
[13:41:44 INF] Generating B-2
[13:41:45 INF] WorkItem { Name = B-2 }
```

## SequentialParallel

```console
[20:34:52 INF] Using SequentialParallel
[20:34:52 INF] Using SequentialFrom with items ItemSource.B(logger)
[20:34:52 INF] Using SequentialFrom with items ItemSource.A(logger)
[20:34:52 INF] Generating B-0
[20:34:52 INF] Generating A-0
[20:34:53 INF] WorkItem { Name = B-0 }
[20:34:53 INF] WorkItem { Name = A-0 }
[20:34:53 INF] Generating B-1
[20:34:53 INF] Generating A-1
[20:34:54 INF] WorkItem { Name = B-1 }
[20:34:54 INF] Generating B-2
[20:34:54 INF] WorkItem { Name = A-1 }
[20:34:54 INF] Generating A-2
[20:34:55 INF] WorkItem { Name = A-2 }
[20:34:55 INF] WorkItem { Name = B-2 }
```

## Pipeline.Run

```console
[21:24:53 INF] Generating B-0
[21:24:53 INF] Generating A-0
[21:24:54 INF] Generating A-1
[21:24:54 INF] Generating B-1
[21:24:54 INF] ["WorkItem { Name = A-0 }", "WorkItem { Name = B-0 }"]
[21:24:55 INF] Generating B-2
[21:24:55 INF] Generating A-2
[21:24:55 INF] ["WorkItem { Name = A-1 }", "WorkItem { Name = B-1 }"]
[21:24:56 INF] ["WorkItem { Name = A-2 }", "WorkItem { Name = B-2 }"]
```
